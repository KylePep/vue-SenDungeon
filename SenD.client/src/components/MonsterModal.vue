<script>
import { ref } from "vue";
import Pop from "../utils/Pop.js";
import { Modal } from "bootstrap";
import { monstersService } from "../services/MonstersService.js";
import { logger } from "../utils/Logger.js";

export default {
  setup() {
    const editable = ref({})
    editable.value.img = 'none'
    editable.value.type = 'none'
    editable.value.subType = 'none'
    return {
      editable,
      async createMonster() {
        try {
          const monsterData = editable.value
          logger.log(monsterData)
          await monstersService.createMonster(monsterData)
          editable.value = {}
          Modal.getOrCreateInstance('#MonsterModal').hide()
        } catch (error) {
          Pop.error(error.message, '[ERROR - createMonster]')
        }
      }
    }
  }
}
</script>


<template>

  <!-- Modal -->
  <div class="modal fade" id="MonsterModal" tabindex="-1" aria-labelledby="MonsterModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="MonsterModalLabel"> Make a Monster </h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <form @submit.prevent="createMonster()" action="">
          <div class="modal-body">
            <div class="mb-3">
              <label for="nameInput" class="form-label">Name</label>
              <input v-model="editable.name" type="string" class="form-control" id="nameInput" placeholder="Name">
            </div>
            <div class="mb-3">
              <label for="imageInput" class="form-label d-block">Image</label>
              <img v-if="editable.img == 'none'" src="https://64.media.tumblr.com/tumblr_m85o660oYG1r4tcmlo1_400.gif"
                class="monster-icon" alt="">
              <img v-else class="monster-icon" :src="editable.img" alt="">
              <select v-model="editable.img" class="form-select" aria-label="Default select example">
                <option value="none" selected>Choose an image</option>
                <option value="https://pixeljoint.com/files/icons/full/vincentspritev2.gif">Vampire</option>
                <option value="https://wiki.dfo-world.com/images/2/23/AdaptingJagos.gif">Goop</option>
                <option value="https://64.media.tumblr.com/tumblr_m85o660oYG1r4tcmlo1_400.gif">
                  Pig</option>
              </select>
            </div>
            <div class="mb-3">
              <!-- <label for="statInput" class="form-label">Stats</label> -->
              <!-- <input type="number" class="form-control" id="hpInput" placeholder="hp"> -->
              <label for="statInput" class="form-label">type</label>
              <select v-model="editable.type" class="form-select" aria-label="Default select example">
                <option value="none" selected>Choose a type</option>
                <option value="undead">Undead</option>
                <option value="horror">Horror</option>
                <option value="beast">
                  Beast</option>
              </select>
              <label for="statInput" class="form-label">sub-type</label>
              <select v-model="editable.subType" class="form-select" aria-label="Default select example">
                <option value="none" selected>Choose a sub-type</option>
                <option value="fire">Fire</option>
                <option value="water">Water</option>
                <option value="earth">
                  Earth</option>
              </select>
              <label for="statInput" class="form-label">power</label>
              <input v-model="editable.power" type="number" class="form-control" id="powerInput" placeholder="power">
              <label for="statInput" class="form-label">toughness</label>
              <input v-model="editable.toughness" type="number" class="form-control" id="toughnessInput"
                placeholder="toughness">
            </div>
            <div class="mb-3">
              <label for="descriptionInput" class="form-label">Description</label>
              <textarea v-model="editable.description" class="form-control" id="descriptionInput" rows="3"></textarea>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="submit" class="btn btn-primary">Create</button>
          </div>
        </form>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.monster-icon {
  height: 200px;
  width: auto;
}
</style>