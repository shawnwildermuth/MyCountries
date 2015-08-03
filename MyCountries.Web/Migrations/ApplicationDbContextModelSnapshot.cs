﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using MyCountries.Web.Data;
using Microsoft.Data.Entity.Migrations.Infrastructure;

namespace ASPNET5New.Migrations
{
  [ContextType(typeof(MyCountriesContext))]
  partial class ApplicationDbContextModelSnapshot : ModelSnapshot
  {
    public override IModel Model
    {
      get
      {
        var builder = new ModelBuilder(null)
            .Annotation("SqlServer:ValueGeneration", "Identity");

        builder.Entity("ASPNET5New.Models.ApplicationUser", b =>
        {
          b.Property<int>("AccessFailedCount")
              .Annotation("OriginalValueIndex", 0);
          b.Property<string>("ConcurrencyStamp")
              .ConcurrencyToken()
              .Annotation("OriginalValueIndex", 1);
          b.Property<string>("Email")
              .Annotation("OriginalValueIndex", 2);
          b.Property<bool>("EmailConfirmed")
              .Annotation("OriginalValueIndex", 3);
          b.Property<string>("Id")
              .ValueGeneratedOnAdd()
              .Annotation("OriginalValueIndex", 4);
          b.Property<bool>("LockoutEnabled")
              .Annotation("OriginalValueIndex", 5);
          b.Property<DateTimeOffset?>("LockoutEnd")
              .Annotation("OriginalValueIndex", 6);
          b.Property<string>("NormalizedEmail")
              .Annotation("OriginalValueIndex", 7);
          b.Property<string>("NormalizedUserName")
              .Annotation("OriginalValueIndex", 8);
          b.Property<string>("PasswordHash")
              .Annotation("OriginalValueIndex", 9);
          b.Property<string>("PhoneNumber")
              .Annotation("OriginalValueIndex", 10);
          b.Property<bool>("PhoneNumberConfirmed")
              .Annotation("OriginalValueIndex", 11);
          b.Property<string>("SecurityStamp")
              .Annotation("OriginalValueIndex", 12);
          b.Property<bool>("TwoFactorEnabled")
              .Annotation("OriginalValueIndex", 13);
          b.Property<string>("UserName")
              .Annotation("OriginalValueIndex", 14);
          b.Key("Id");
          b.Annotation("Relational:TableName", "AspNetUsers");
        });

        builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
        {
          b.Property<string>("ConcurrencyStamp")
              .ConcurrencyToken()
              .Annotation("OriginalValueIndex", 0);
          b.Property<string>("Id")
              .ValueGeneratedOnAdd()
              .Annotation("OriginalValueIndex", 1);
          b.Property<string>("Name")
              .Annotation("OriginalValueIndex", 2);
          b.Property<string>("NormalizedName")
              .Annotation("OriginalValueIndex", 3);
          b.Key("Id");
          b.Annotation("Relational:TableName", "AspNetRoles");
        });

        builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
        {
          b.Property<string>("ClaimType")
              .Annotation("OriginalValueIndex", 0);
          b.Property<string>("ClaimValue")
              .Annotation("OriginalValueIndex", 1);
          b.Property<int>("Id")
              .ValueGeneratedOnAdd()
              .Annotation("OriginalValueIndex", 2)
              .Annotation("SqlServer:ValueGeneration", "Default");
          b.Property<string>("RoleId")
              .Annotation("OriginalValueIndex", 3);
          b.Key("Id");
          b.Annotation("Relational:TableName", "AspNetRoleClaims");
        });

        builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
        {
          b.Property<string>("ClaimType")
              .Annotation("OriginalValueIndex", 0);
          b.Property<string>("ClaimValue")
              .Annotation("OriginalValueIndex", 1);
          b.Property<int>("Id")
              .ValueGeneratedOnAdd()
              .Annotation("OriginalValueIndex", 2)
              .Annotation("SqlServer:ValueGeneration", "Default");
          b.Property<string>("UserId")
              .Annotation("OriginalValueIndex", 3);
          b.Key("Id");
          b.Annotation("Relational:TableName", "AspNetUserClaims");
        });

        builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
        {
          b.Property<string>("LoginProvider")
              .ValueGeneratedOnAdd()
              .Annotation("OriginalValueIndex", 0);
          b.Property<string>("ProviderDisplayName")
              .Annotation("OriginalValueIndex", 1);
          b.Property<string>("ProviderKey")
              .ValueGeneratedOnAdd()
              .Annotation("OriginalValueIndex", 2);
          b.Property<string>("UserId")
              .Annotation("OriginalValueIndex", 3);
          b.Key("LoginProvider", "ProviderKey");
          b.Annotation("Relational:TableName", "AspNetUserLogins");
        });

        builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
        {
          b.Property<string>("RoleId")
              .Annotation("OriginalValueIndex", 0);
          b.Property<string>("UserId")
              .Annotation("OriginalValueIndex", 1);
          b.Key("UserId", "RoleId");
          b.Annotation("Relational:TableName", "AspNetUserRoles");
        });

        builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
        {
          b.Reference("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", "RoleId");
        });

        builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
        {
          b.Reference("ASPNET5New.Models.ApplicationUser", "UserId");
        });

        builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
        {
          b.Reference("ASPNET5New.Models.ApplicationUser", "UserId");
        });

        builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
        {
          b.Reference("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", "RoleId");
          b.Reference("ASPNET5New.Models.ApplicationUser", "UserId");
        });

        return builder.Model;
      }
    }
  }
}
