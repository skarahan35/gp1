﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSell.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSubGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSubGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EndUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    SurName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EMail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    Address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Password = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prefixes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Parameter = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    BeUsed = table.Column<bool>(type: "boolean", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefixes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockSubGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSubGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Condition = table.Column<bool>(type: "boolean", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    InternationalCode = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomerTypeID = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerGroupID = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxOffice = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    TaxNo = table.Column<int>(type: "integer", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    AuthorizedPerson = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    EMail = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    RiskLimit = table.Column<decimal>(type: "numeric", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCards_CustomerGroups_CustomerGroupID",
                        column: x => x.CustomerGroupID,
                        principalTable: "CustomerGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCards_CustomerTypes_CustomerTypeID",
                        column: x => x.CustomerTypeID,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Road = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Street = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    BuildingName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    BuildingNo = table.Column<int>(type: "integer", nullable: true),
                    PostCode = table.Column<int>(type: "integer", nullable: true),
                    DistrictID = table.Column<Guid>(type: "uuid", nullable: false),
                    CityID = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryID = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxNo = table.Column<int>(type: "integer", nullable: true),
                    TaxOffice = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Currency = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    DateFormat = table.Column<int>(type: "integer", nullable: true),
                    WebSite = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    IncomingMail = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    SendingMail = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    WorkingYear = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    QuantityDecimal = table.Column<int>(type: "integer", nullable: true),
                    PriceDecimal = table.Column<int>(type: "integer", nullable: true),
                    AmountDecimal = table.Column<int>(type: "integer", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Districts_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    StockTypeID = table.Column<Guid>(type: "uuid", nullable: false),
                    StockUnitID = table.Column<Guid>(type: "uuid", nullable: false),
                    StockGroupID = table.Column<Guid>(type: "uuid", nullable: false),
                    TransferredQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    AvailableQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalEntryQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalOutputQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    VATRate = table.Column<int>(type: "integer", nullable: true),
                    DiscountRate = table.Column<int>(type: "integer", nullable: true),
                    CurrencyType = table.Column<int>(type: "integer", maxLength: 64, nullable: true),
                    Price1 = table.Column<decimal>(type: "numeric(12,6)", nullable: true),
                    Price2 = table.Column<decimal>(type: "numeric(12,6)", nullable: true),
                    Price3 = table.Column<decimal>(type: "numeric(12,6)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockCards_StockGroups_StockGroupID",
                        column: x => x.StockGroupID,
                        principalTable: "StockGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockCards_StockTypes_StockTypeID",
                        column: x => x.StockTypeID,
                        principalTable: "StockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockCards_StockUnits_StockUnitID",
                        column: x => x.StockUnitID,
                        principalTable: "StockUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Road = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Street = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    BuildingName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    BuildingNo = table.Column<int>(type: "integer", nullable: true),
                    PostCode = table.Column<int>(type: "integer", nullable: true),
                    CustomerCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_CustomerCards_CustomerCardId",
                        column: x => x.CustomerCardId,
                        principalTable: "CustomerCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovementHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeCode = table.Column<int>(type: "integer", maxLength: 64, nullable: true),
                    ReceiptNo = table.Column<int>(type: "integer", precision: 10, nullable: true),
                    CustomerCardID = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    VATAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    AddressID = table.Column<Guid>(type: "uuid", nullable: true),
                    PaymentType = table.Column<int>(type: "integer", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementHeaders_CustomerCards_AddressID",
                        column: x => x.AddressID,
                        principalTable: "CustomerCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovementHeaders_CustomerCards_CustomerCardID",
                        column: x => x.CustomerCardID,
                        principalTable: "CustomerCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StockCardID = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(12,6)", nullable: true),
                    PriceType = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockPrices_StockCards_StockCardID",
                        column: x => x.StockCardID,
                        principalTable: "StockCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovementDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeCode = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    ReceiptNo = table.Column<int>(type: "integer", precision: 10, nullable: true),
                    StockCardID = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(12,6)", nullable: true),
                    DiscountRate = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    VATRate = table.Column<decimal>(type: "numeric", nullable: true),
                    VATAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    FirstAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    HeaderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementDetails_MovementHeaders_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "MovementHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovementDetails_StockCards_StockCardID",
                        column: x => x.StockCardID,
                        principalTable: "StockCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityID",
                table: "Companies",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryID",
                table: "Companies",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_DistrictID",
                table: "Companies",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CityId",
                table: "CustomerAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CountryId",
                table: "CustomerAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CustomerCardId",
                table: "CustomerAddresses",
                column: "CustomerCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_DistrictId",
                table: "CustomerAddresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCards_CustomerGroupID",
                table: "CustomerCards",
                column: "CustomerGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCards_CustomerTypeID",
                table: "CustomerCards",
                column: "CustomerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetails_HeaderId",
                table: "MovementDetails",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetails_StockCardID",
                table: "MovementDetails",
                column: "StockCardID");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHeaders_AddressID",
                table: "MovementHeaders",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHeaders_CustomerCardID",
                table: "MovementHeaders",
                column: "CustomerCardID");

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_StockGroupID",
                table: "StockCards",
                column: "StockGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_StockTypeID",
                table: "StockCards",
                column: "StockTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_StockCards_StockUnitID",
                table: "StockCards",
                column: "StockUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_StockCardID",
                table: "StockPrices",
                column: "StockCardID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "CustomerSubGroups");

            migrationBuilder.DropTable(
                name: "EndUsers");

            migrationBuilder.DropTable(
                name: "MovementDetails");

            migrationBuilder.DropTable(
                name: "Prefixes");

            migrationBuilder.DropTable(
                name: "StockPrices");

            migrationBuilder.DropTable(
                name: "StockSubGroups");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "MovementHeaders");

            migrationBuilder.DropTable(
                name: "StockCards");

            migrationBuilder.DropTable(
                name: "CustomerCards");

            migrationBuilder.DropTable(
                name: "StockGroups");

            migrationBuilder.DropTable(
                name: "StockTypes");

            migrationBuilder.DropTable(
                name: "StockUnits");

            migrationBuilder.DropTable(
                name: "CustomerGroups");

            migrationBuilder.DropTable(
                name: "CustomerTypes");
        }
    }
}
