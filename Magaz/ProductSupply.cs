//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Magaz
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSupply
    {
        public int IdProductSupply { get; set; }
        public int CountProduct { get; set; }
        public int IdProduct { get; set; }
        public int IdSupply { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
