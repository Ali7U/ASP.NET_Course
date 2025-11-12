using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Appointments_AppointmentsId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Appointments_AppointmentsId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AppointmentsId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AppointmentsId",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentsId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentsId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AppointmentsPatient",
                columns: table => new
                {
                    AppointmentsId = table.Column<int>(type: "int", nullable: false),
                    PatientsPatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentsPatient", x => new { x.AppointmentsId, x.PatientsPatientId });
                    table.ForeignKey(
                        name: "FK_AppointmentsPatient_Appointments_AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentsPatient_Patients_PatientsPatientId",
                        column: x => x.PatientsPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AppointmentsId",
                table: "Doctors",
                column: "AppointmentsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentsPatient_PatientsPatientId",
                table: "AppointmentsPatient",
                column: "PatientsPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Appointments_AppointmentsId",
                table: "Doctors",
                column: "AppointmentsId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Appointments_AppointmentsId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "AppointmentsPatient");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AppointmentsId",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentsId",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentsId",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AppointmentsId",
                table: "Patients",
                column: "AppointmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AppointmentsId",
                table: "Doctors",
                column: "AppointmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Appointments_AppointmentsId",
                table: "Doctors",
                column: "AppointmentsId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Appointments_AppointmentsId",
                table: "Patients",
                column: "AppointmentsId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }
    }
}
