using System.ComponentModel;

namespace ProductCatalog.Domain.AuxModels
{
    public enum ProductType
    {
        [Description("Orgânico")]
        ORGANICO = 0,

        [Description("Não Orgânico")]
        NAO_ORGANICO = 1,
    }
}
