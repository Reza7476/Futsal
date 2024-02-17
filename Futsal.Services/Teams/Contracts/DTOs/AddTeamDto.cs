using Futsal.Entities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Services.Teams.Contracts.DTOs;
public class AddTeamDto
{
    public string Name { get; set; }
    public ColorDress ColorDressOrigin { get; set; }
    public ColorDress ColorDressNormal { get; set; }
}
