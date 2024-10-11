using AutoMapper;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var featureSlider = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(featureSlider);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderID == id);
        }

        public async Task FeatureSliderChangeStatusToFalse(string id)
        {
            var featureSlider = await _featureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            featureSlider.Status = false;
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderID == id, featureSlider);
        }

        public async Task FeatureSliderChangeStatusToTrue(string id)
        {
            var featureSlider = await _featureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            featureSlider.Status = true;
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderID == id, featureSlider);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var featureSliders = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(featureSliders);
        }

        public async Task<GetFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id)
        {
            var featureSlider = await _featureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeatureSliderByIdDto>(featureSlider);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var featureSlider = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderID == updateFeatureSliderDto.FeatureSliderID, featureSlider);
        }
    }
}
