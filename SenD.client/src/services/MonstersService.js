import { AppState } from "../AppState.js"
import { Monster } from "../models/Monster.js"

class MonstersService {
  // Create Monster
  async createMonster(monsterData) {
    const res = await api.get(`api/monsters`, monsterData)
    const monster = new Monster(res.data)
    AppState.monsters.unshift(monster)
  }
  // Get Monsters
  async getMonsters() {
    const res = await api.get('api/monsters')
    const monsters = res.data.map(m => new Monster(m))
    AppState.monsters = monsters
  }
  // Delete/Deprecate Monster
  // Update Monster
}
export const monstersService = new MonstersService()