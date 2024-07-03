<script setup>
import { computed, ref, watchEffect } from "vue";
import { logger } from "../utils/Logger.js";
import { AppState } from "../AppState.js";

const props = defineProps(['button', 'modal', 'purpose', 'btnColor'])
const modalValues = ref({ header: 'bean', send: '', purpose: '' })
const userActivity = computed(() => AppState.userActivity)

const setUpModal = () => {
  AppState.userActivity = props.purpose
}

watchEffect(() => {
  if (userActivity.value == 'createMonster') {
    modalValues.value.header = 'Make a Monster'
    modalValues.value.send = 'Finalize Creation!'
  } else {
    modalValues.value.header = 'Write you Message'
    modalValues.value.send = 'Send Message!'
  }
  logger.log('USER ACTIVITY', userActivity.value, 'MODAL VALUES', modalValues.value)
})

</script>


<template>

  <a @click="setUpModal()" type="button" v-if="props.button == 'true'" class="btn" :class="props.btnColor"
    data-bs-toggle="modal" data-bs-target="#SenDModal">
    <slot name="icon">

    </slot>
  </a>

  <!-- Modal -->
  <div v-if="props.modal == 'true'" class="modal fade" id="SenDModal" tabindex="-1" aria-labelledby="SenDModalLabel"
    aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="SenDModalLabel"> {{ modalValues.header }} </h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <form @submit.prevent="" action="">
          <div v-if="modalValues.header == 'Write you Message'" class="modal-body">
            <div class="mb-3">
              <label for="exampleFormControlInput1" class="form-label">Email address</label>
              <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com">
            </div>
            <div class="mb-3">
              <label for="exampleFormControlTextarea1" class="form-label">Example textarea</label>
              <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">{{ modalValues.send }}</button>
          </div>
        </form>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped></style>