<script setup>
import { onMounted } from "vue";
import Pop from "../utils/Pop.js";
import { monstersService } from "../services/MonstersService.js";

async function getMonsters() {
  try {
    await monstersService.getMonsters()
  } catch (error) {
    Pop.error(error.message, '[ERROR - getMonsters]')
  }
}

onMounted(() => {
  getMonsters()
})
</script>


<template>
  <div class="col-12 mb-3">
    <section>
      <h1>
        In this section you'll be able to see the home page
      </h1>
      <h2>
        The home page will present the options of creating a monster or sending a message to another user
      </h2>
    </section>
  </div>
  <div class="col-12 mb-3">
    <button class="btn btn-success" data-bs-toggle="modal" data-bs-target="#MonsterModal">
      Monster
    </button>
  </div>
  <div class="col-12">
    <button class="btn btn-info" data-bs-toggle="modal" data-bs-target="#MessageModal">
      Message
    </button>
  </div>
</template>


<style lang="scss" scoped></style>
