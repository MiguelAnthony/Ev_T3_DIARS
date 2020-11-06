﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T3_DIARS.Models.Map
{
    public class EjerciciosMap : IEntityTypeConfiguration<Ejercicios>
    {
        public void Configure(EntityTypeBuilder<Ejercicios> builder)
        {
            builder.ToTable("Reg_Ejercicios");
            builder.HasKey(o => o.Id);
        }
    }
}
