using SchoolDBProject.Services;
using SchoolDBProject.Models;

//przykladowe zapytania w postaci linkow, port moze sie roznic
//https://localhost:7053/api/students/get-all-students
//https://localhost:7053/api/students/get-students-by-class/1357724365
//https://localhost:7053/api/Teachers/get-teachers-by-subject/1356849531
//pelna liste dostepnych zapytan mozna znalezc po uruchomieniu projektu i przejsciu do interfejsu Swagger

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<StudentService>();  
builder.Services.AddSingleton<ParentService>();
builder.Services.AddSingleton<TeacherService>();
builder.Services.AddSingleton<EmployeeService>();
builder.Services.AddSingleton<ClassService>();
builder.Services.AddSingleton<SubjectService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


