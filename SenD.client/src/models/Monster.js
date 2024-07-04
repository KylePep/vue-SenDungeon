export class Monster {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.img = data.img
    this.stats = data.stats
    this.creator = data.creator
    this.description = data.description
    this.monsterMessageId = data.monsterMessageId
    // {
    //   hp = data.stats.hp
    //   type = data.stats.type
    //   subType = data.stats.subType
    //   power = data.stats.power
    //   toughness = data.stats.power
    // }
  }
}