<script>
import { ref } from "vue";
import Pop from "../utils/Pop.js";
import { Modal } from "bootstrap";
import { monstersService } from "../services/MonstersService.js";

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
        <form @submit.prevent="" action="">
          <div class="modal-body">
            <div class="mb-3">
              <label for="nameInput" class="form-label">Name</label>
              <input type="string" class="form-control" id="nameInput" placeholder="Name">
            </div>
            <div class="mb-3">
              <label for="imageInput" class="form-label d-block">Image</label>
              <img v-if="editable.img == 'none'"
                src="https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/3ce212da-22a2-4830-85cc-f5e5affc5cd6/dcxehfe-dd22d80d-4cff-49bf-be56-bb51f5ea0a78.gif?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzNjZTIxMmRhLTIyYTItNDgzMC04NWNjLWY1ZTVhZmZjNWNkNlwvZGN4ZWhmZS1kZDIyZDgwZC00Y2ZmLTQ5YmYtYmU1Ni1iYjUxZjVlYTBhNzguZ2lmIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.FPZzigXwn6ZWFixDogw4z5uQbIfnJSzyq8TDI9K_3o8"
                class="monster-icon" alt="">
              <img v-else class="monster-icon" :src="editable.img" alt="">
              <select v-model="editable.img" class="form-select" aria-label="Default select example">
                <option value="none" selected>Choose an image</option>
                <option value="https://pixeljoint.com/files/icons/full/vincentspritev2.gif">Vampire</option>
                <option value="https://wiki.dfo-world.com/images/2/23/AdaptingJagos.gif">Goop</option>
                <option
                  value="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSoQYDuXTPz_x6xWYBinjjVNp9RAent_R3BOg24yH9MOdmJ-4pK1YIyKmMaRd1EjEzcRMA&usqp=CAU">
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
              <input type="number" class="form-control" id="powerInput" placeholder="power">
              <label for="statInput" class="form-label">toughness</label>
              <input type="number" class="form-control" id="toughnessInput" placeholder="toughness">
            </div>
            <div class="mb-3">
              <label for="descriptionInput" class="form-label">Description</label>
              <textarea class="form-control" id="descriptionInput" rows="3"></textarea>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Create</button>
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