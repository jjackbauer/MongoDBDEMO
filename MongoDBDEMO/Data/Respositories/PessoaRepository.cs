using MongoDB.Driver;
using MongoDBDEMO.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBDEMO.Data.Respositories
{
    public class PessoaRepository 
    {
        private readonly PessoaMongoDbCollection _context;

        public PessoaRepository(PessoaMongoDbCollection context)
        {
            _context = context;
        }
        public async Task AdicionaPessoa(Pessoa pessoa)
        {
            await _context.Pessoas.InsertOneAsync(pessoa);
        }
        public async Task<List<Pessoa>> RecuperaPessoas()
        {
            return await _context.Pessoas.FindAsync(Builders<Pessoa>.Filter.Empty).GetAwaiter().GetResult().ToListAsync();
        }
    }
}
