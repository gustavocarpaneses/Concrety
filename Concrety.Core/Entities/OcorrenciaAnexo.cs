using Concrety.Core.Entities.Base;

namespace Concrety.Core.Entities
{
    public class OcorrenciaAnexo : EntityBase
    {
        public virtual Ocorrencia Ocorrencia { get; set; }
        public int IdOcorrencia { get; set; }

        public virtual Anexo Anexo { get; set; }
        public int IdAnexo { get; set; }
    }
}
