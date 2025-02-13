﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
public class ChequePromissionaryNoteConfig : IEntityTypeConfiguration<ChequePromissionaryNote>
{
    void IEntityTypeConfiguration<ChequePromissionaryNote>.Configure(EntityTypeBuilder<ChequePromissionaryNote> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder,"ChequePromissionaryNotes");
        builder.Property(x => x.Number).IsRequired();
    }
}

