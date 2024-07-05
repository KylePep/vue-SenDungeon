namespace SenD.Services;

public class MonstersService
{
  private readonly MonstersRepository _monstersRepository;

  public MonstersService(MonstersRepository monstersRepository)
  {
    _monstersRepository = monstersRepository;
  }

  internal Monster createMonster(Monster monsterData)
  {
    int monsterId = _monstersRepository.createMonster(monsterData);
    Monster monster = getMonsterById(monsterId);
    return monster;
  }

  internal Monster getMonsterById(int monsterId)
  {
    Monster monster = _monstersRepository.getMonsterById(monsterId);
    if (monster == null)
    {
      throw new Exception($"Bad Monster ID: {monsterId}");
    }
    return monster;
  }

  internal List<Monster> getMonsters()
  {
    List<Monster> monsters = _monstersRepository.getMonsters();
    return monsters;
  }
}