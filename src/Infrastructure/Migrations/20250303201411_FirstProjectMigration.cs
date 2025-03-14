using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstProjectMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    user_name = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    password = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "wallets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    balance = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallets", x => x.id);
                    table.ForeignKey(
                        name: "FK_wallets_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    type = table.Column<string>(type: "text", nullable: false),
                    WalletId = table.Column<int>(type: "integer", nullable: false),
                    TargetWalletId = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_wallets_TargetWalletId",
                        column: x => x.TargetWalletId,
                        principalTable: "wallets",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_TargetWalletId",
                table: "transactions",
                column: "TargetWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_WalletId",
                table: "transactions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "idx_users_email",
                table: "users",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_wallets_UserId",
                table: "wallets",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "wallets");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
