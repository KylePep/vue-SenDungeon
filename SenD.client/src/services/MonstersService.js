import { AppState } from "../AppState.js"
import { Monster } from "../models/Monster.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class MonstersService {
  // Create Monster
  async createMonster(monsterData) {
    const res = await api.get(`api/monsters`, monsterData)
    const monster = new Monster(res.data)
    logger.log('CREATE MONSTER', monster)

    AppState.monsters.unshift(monster)
  }
  // Get Monsters
  async getMonsters() {
    const res = await api.get('api/monsters')
    const monsters = res.data.map(m => new Monster(m))
    logger.log('GET MONSTERS', monsters)
    AppState.monsters = monsters
  }
  // Delete/Deprecate Monster
  // Update Monster
}
export const monstersService = new MonstersService()