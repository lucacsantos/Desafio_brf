using GestaoPessoa.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace GestaoPessoa.Services
{
    public class PessoaService
    {
        private readonly IMongoCollection<Pessoa> _pessoaCollection;

        public PessoaService(
            IOptions<GestaoPessoaDatabaseSettings> gestaoPessoaDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                gestaoPessoaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                gestaoPessoaDatabaseSettings.Value.DatabaseName);

            _pessoaCollection = mongoDatabase.GetCollection<Pessoa>(
                gestaoPessoaDatabaseSettings.Value.PessoaCollectionName);
        }
        public async Task<List<Pessoa>> GetAll() =>
            await _pessoaCollection.Find(_ => true).ToListAsync();

        public async Task<Pessoa?> GetById(string id) =>
            await _pessoaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task Create(Pessoa newPessoa) =>
        await _pessoaCollection.InsertOneAsync(newPessoa);

        public async Task Update(string id, Pessoa updatePessoa) =>
       await _pessoaCollection.ReplaceOneAsync(x => x.Id == id, updatePessoa);

        public async Task Delete(string id) =>
            await _pessoaCollection.DeleteOneAsync(x => x.Id == id);

    }
}
