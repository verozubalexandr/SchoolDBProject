using SchoolDBProject.Services;
using SchoolDBProject.Models;

//https://localhost:7053/api/students/get-all-students

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


