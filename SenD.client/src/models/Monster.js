export class Monster {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.img = data.img
    this.creator = data.creator
    this.description = data.description
    // this.monsterMessageId = data.monsterMessageId
    this.type = data.type
    this.subType = data.subType
    this.power = data.power
    this.toughness = data.power
  }
}