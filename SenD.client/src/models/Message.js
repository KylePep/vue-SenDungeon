export class Message {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.recipientId = data.recipientId
    this.content = data.content
  }
}