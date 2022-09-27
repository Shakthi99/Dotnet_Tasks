﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task4Training.Interface;

namespace Task4Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkill _skill;
        public SkillsController(ISkill skill)
        {
            _skill = skill;
        }

        // GET: api/Skills
        [HttpGet]
        [Route("GetSkillsData")]
        public async Task<IActionResult> GetSkillsData()
        {
            try
            {
                var result = await _skill.GetAllSkills();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
    
