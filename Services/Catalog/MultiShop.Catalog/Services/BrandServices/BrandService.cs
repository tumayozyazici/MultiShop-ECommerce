using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandSevices
{
    public class BrandService : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Brand> _brandCollection;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var brand = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(brand);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.FindOneAndDeleteAsync(x => x.BrandID == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var brands = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(brands);
        }

        public async Task<GetBrandByIdDto> GetBrandByIdAsync(string id)
        {
            var brand = await _brandCollection.Find(x => x.BrandID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetBrandByIdDto>(brand);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var brand = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandID == updateBrandDto.BrandID, brand);
        }
    }
}
