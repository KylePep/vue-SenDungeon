export class Monster {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.img = data.img
    this.creator = data.creator
    this.description = data.description
    // this.monsterMessageId = data.monsterMessageId
    this.type = data.stats.type
    this.subType = data.stats.subType
    this.power = data.stats.power
    this.toughness = data.stats.power
  }
}