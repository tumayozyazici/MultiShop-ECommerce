using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollecytion;
        private readonly IMapper _mapper;

        public FeatureService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollecytion = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollecytion.InsertOneAsync(feature);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollecytion.FindOneAndDeleteAsync(x => x.FeatureID == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var features = await _featureCollecytion.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(features);
        }

        public async Task<GetFeatureByIdDto> GetFeatureByIdAsync(string id)
        {
            var feature = await _featureCollecytion.Find(x => x.FeatureID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeatureByIdDto>(feature);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            await _featureCollecytion.FindOneAndReplaceAsync(x => x.FeatureID == updateFeatureDto.FeatureID, feature);
        }
    }
}
