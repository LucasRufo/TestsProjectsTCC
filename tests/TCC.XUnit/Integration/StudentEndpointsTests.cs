using TCC.Common.Extensions;
using System.Net.Http.Json;
using TCC.Alunos;

namespace TCC.XUnit.Integration;

public class StudentEndpointsTests : BaseIntegrationTests
{
    [Fact]
    public async Task ShouldGetAllStudents()
    {
        //arrange
        var fakeStudent = new StudentBuilder().Generate();
        await _client.PostAsync("/students", fakeStudent.ToJsonContent());

        //act
        var students = await _client.GetFromJsonAsync<List<Student>>("/students");

        //assert
        students.Should().ContainEquivalentOf(new 
        {
            fakeStudent.Name,
            fakeStudent.Age,
            fakeStudent.Classes
        });
    }

    [Fact]
    public async Task ShouldGetStudentById()
    {
        //arrange
        var fakeStudent = new StudentBuilder().Generate();
        var response = await _client.PostAsync("/students", fakeStudent.ToJsonContent());
        var studentResponse = await response.Content.ReadFromJsonAsync<Student>();

        //act
        var student = await _client.GetFromJsonAsync<Student>($"/students/{studentResponse?.Id}");

        //assert
        student.Should().BeEquivalentTo(new
        {
            fakeStudent.Name,
            fakeStudent.Age,
            fakeStudent.Classes
        });
    }

    [Fact]
    public async Task ShouldCreateStudent()
    {
        //arrange
        var fakeStudent = new StudentBuilder().Generate();

        //act
        var response = await _client.PostAsync("/students", fakeStudent.ToJsonContent());
        var studentResponse = await response.Content.ReadFromJsonAsync<Student>();

        //assert
        studentResponse.Should().BeEquivalentTo(new
        {
            fakeStudent.Name,
            fakeStudent.Age,
            fakeStudent.Classes
        });
    }


    [Fact]
    public async Task ShouldUpdateStudent()
    {
        //arrange
        var fakeStudent = new StudentBuilder().Generate();
        var response = await _client.PostAsync("/students", fakeStudent.ToJsonContent());
        var studentResponse = await response.Content.ReadFromJsonAsync<Student>();

        fakeStudent.Id = studentResponse!.Id;

        //act
        var putResponse = await _client.PutAsJsonAsync($"/students/{studentResponse?.Id}", fakeStudent);
        var updatedStudent = await putResponse.Content.ReadFromJsonAsync<Student>();

        //assert
        updatedStudent.Should().BeEquivalentTo(new
        {
            fakeStudent.Name,
            fakeStudent.Age,
            fakeStudent.Classes
        });
    }

    [Fact]
    public async Task ShouldDeleteStudent()
    {
        //arrange
        var fakeStudent = new StudentBuilder().Generate();
        var response = await _client.PostAsync("/students", fakeStudent.ToJsonContent());
        var studentResponse = await response.Content.ReadFromJsonAsync<Student>();

        fakeStudent.Id = studentResponse!.Id;

        //act
        var deleteResponse = await _client.DeleteAsync($"/students/{studentResponse?.Id}");
        var deletedStudent = await deleteResponse.Content.ReadFromJsonAsync<Student>();

        //assert
        deletedStudent.Should().BeEquivalentTo(new
        {
            fakeStudent.Name,
            fakeStudent.Age,
            fakeStudent.Classes
        });
    }
}
