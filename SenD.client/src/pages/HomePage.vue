<script setup>
import SenDModal from "../components/SenDModal.vue";
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
    <SenDModal button="true" modal="false" purpose="monster">
      <template #icon>
        <button class="btn btn-success">
          Monster
        </button>
      </template>
    </SenDModal>
  </div>
  <div class="col-12">
    <SenDModal button="true" modal="false" purpose="message">
      <template #icon>
        <button class="btn btn-info">
          Monster
        </button>
      </template>
    </SenDModal>
  </div>
</template>


<style lang="scss" scoped></style>
