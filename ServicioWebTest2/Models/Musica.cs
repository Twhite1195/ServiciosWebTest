//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioWebTest2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Musica
    {
        public int ID_Musica { get; set; }
        public Nullable<int> Genero_Musica { get; set; }
        public string Nombre_Musica { get; set; }
        public string Tipo_Inerpretacion_Musica { get; set; }
        public Nullable<int> Idioma_Musica { get; set; }
        public Nullable<int> Pais_Musica { get; set; }
        public Nullable<int> Disquera_Musica { get; set; }
        public Nullable<int> Disco_Musica { get; set; }
        public System.DateTime Ano_Musica { get; set; }
    
        public virtual Disco Disco { get; set; }
        public virtual Disquera Disquera { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Idioma Idioma { get; set; }
        public virtual Pai Pai { get; set; }
    }
}
