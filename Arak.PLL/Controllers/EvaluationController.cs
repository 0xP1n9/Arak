using Arak.BLL.Service.Abstraction;
using Arak.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EvaluationController : ControllerBase
{
    private readonly IEvaluationService _EvaluationService;

    public EvaluationController(IEvaluationService EvaluationService)
    {
        _EvaluationService = EvaluationService;
    }

    [HttpPost]
    [Authorize(Roles = "Teacher,Admin")]
    public async Task<IActionResult> Create(Evaluation evaluation)
    {
        var result = await _EvaluationService.CreateEvaluation(evaluation);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Teacher,Admin")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _EvaluationService.GetAllEvaluations());
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Teacher, Admin")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _EvaluationService.GetEvaluationById(id));
    }

    [HttpGet("student/{studentId}")]
    [Authorize(Roles = "Teacher, Admin, Parent")]
    public async Task<IActionResult> GetByStudent(int studentId)
    {
        return Ok(await _EvaluationService.GetEvaluationsByStudentId(studentId));
    }

    [HttpPut]
    [Authorize(Roles = "Teacher,Admin")]
    public async Task<IActionResult> Update(Evaluation evaluation)
    {
        return Ok(await _EvaluationService.UpdateEvaluation(evaluation));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Teacher,Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _EvaluationService.DeleteEvaluation(id));
    }
}