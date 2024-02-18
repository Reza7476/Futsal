using Futsal.Entities.Players;
using Futsal.Entities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Services.Players.Contracts.DTOs;
public class AddPlayerDto
{

    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public PlayerRole PlayerRole { get; set; }
 
}

public class EditPlayerDto
{
    
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public PlayerRole PlayerRole { get; set; }
   // public int TeamId { get; set; }

}
public class PlayerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public PlayerRole PlayerRole { get; set; }
    public int? TeamId { get; set; }
}
public class FilterAgePlayerDto
{
    public int StartAge { get; set; }
    public int EndAge { get; set; }
}

public class AddPlayerToTeamDto
{
    public int TeamId { get; set; }
    public int PlayerId { get; set; }
}