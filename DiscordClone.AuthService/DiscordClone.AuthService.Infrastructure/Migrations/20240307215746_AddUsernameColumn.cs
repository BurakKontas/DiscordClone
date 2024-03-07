using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DiscordClone.AuthService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsernameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "auth",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    useruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    passwordhash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email_verified = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    last_login = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    banned = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("auth_pkey", x => x.id);
                    table.UniqueConstraint("AK_auth_useruuid", x => x.useruuid);
                    table.ForeignKey(
                        name: "auth_role_id_fkey",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bans",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    useruuid = table.Column<Guid>(type: "uuid", nullable: false),
                    adminuuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ban_reason = table.Column<string>(type: "text", nullable: false),
                    ban_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("bans_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_bans_useruuid",
                        column: x => x.useruuid,
                        principalTable: "auth",
                        principalColumn: "useruuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "auth_email_key",
                table: "auth",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "auth_useruuid_key",
                table: "auth",
                column: "useruuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_auth_role_id",
                table: "auth",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "idx_auth_username",
                table: "auth",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "idx_auth_useruuid",
                table: "auth",
                column: "useruuid");

            migrationBuilder.CreateIndex(
                name: "idx_bans_useruuid",
                table: "bans",
                column: "useruuid");

            migrationBuilder.CreateIndex(
                name: "roles_role_key",
                table: "roles",
                column: "role",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bans");

            migrationBuilder.DropTable(
                name: "auth");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
