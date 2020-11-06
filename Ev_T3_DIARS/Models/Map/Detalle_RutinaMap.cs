using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T3_DIARS.Models.Map
{
    public class Detalle_RutinaMap : IEntityTypeConfiguration<Detalle_Rutina>
    {
        public void Configure(EntityTypeBuilder<Detalle_Rutina> builder)
        {
            builder.ToTable("Detalle_Rutina");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Ejercicio).
                WithMany().
                HasForeignKey(o => o.Id_Ejercicios);

        }
    }
}
