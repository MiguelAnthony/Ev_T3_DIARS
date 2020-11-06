using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T3_DIARS.Models.Map
{
    public class Rutina_UsuarioMap : IEntityTypeConfiguration<Rutina_Usuario>
    {
        public void Configure(EntityTypeBuilder<Rutina_Usuario> builder)
        {
            builder.ToTable("RutinaUsuario");
            builder.HasKey(o => o.Id);
        }
    }
}
