using System;

namespace MongoDBDEMO.Business.Entities
{
    public class Pessoa : Entidade
    { 
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
