using System;

namespace MongoDBDEMO.Business.Entities
{
    public class Entidade
    {
        public Guid Id { get; private set; }
        public DateTime MomentoDoRegistro { get; private set; }
        public Entidade()
        {
            Id = Guid.NewGuid();
            MomentoDoRegistro = DateTime.Now;
        }
    }
}
