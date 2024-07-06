namespace SenD.Repositories;
public class MonstersRepository
{
  private readonly IDbConnection _db;
  public MonstersRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int createMonster(Monster monsterData)
  {
    string sql = @"
    INSERT INTO monsters (name, description, img, creatorId, power, toughness, type, subType)
    VALUES (@Name, @Description, @Img, @CreatorId, @Power, @Toughness, @Type, @SubType);
    SELECT LAST_INSERT_ID()
    ;";

    int monsterId = _db.ExecuteScalar<int>(sql, monsterData);
    return monsterId;
  }

  internal Monster getMonsterById(int monsterId)
  {
    string sql = @"
    SELECT
    mn.*,
    acc.*
    FROM monsters mn
    JOIN accounts acc ON acc.id = mn.creatorId
    WHERE mn.id = @monsterId
    ;";

    Monster monster = _db.Query<Monster, Profile, Monster>(
      sql,
      (monster, profile) =>
      {
        monster.Creator = profile;
        return monster;
      }, new { monsterId }
    ).LastOrDefault();
    return monster;
  }

  internal List<Monster> getMonsters()
  {
    string sql = @"
    SELECT
    mn.*,
    acc.*
    FROM monsters mn
    JOIN accounts acc ON acc.id = mn.creatorId
    ORDER BY mn.createdAt DESC
    ;";

    List<Monster> monsters = _db.Query<Monster, Profile, Monster>(
      sql,
      (monster, profile) =>
      {
        monster.Creator = profile;
        return monster;
      }).ToList();
    return monsters;
  }

}