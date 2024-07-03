<script setup>
import { computed, ref, watchEffect } from "vue";
import { logger } from "../utils/Logger.js";
import { AppState } from "../AppState.js";

const props = defineProps(['button', 'modal', 'purpose'])
logger.log(props)
const modalValues = ref({ header: 'bean' })
const userActivity = computed(() => AppState.userActivity)

const setUpModal = () => {
  AppState.userActivity = props.purpose
}

watchEffect(() => {
  if (userActivity == 'monster') {
    modalValues.value.header = 'Create A Monster?'
  } else {
    modalValues.value.header = 'Create A Message?'
  }
})




</script>


<template>

  <a @click="setUpModal()" type="button" v-if="props.button == 'true'" class="" data-bs-toggle="modal"
    data-bs-target="#SenDModal">
    <slot name="icon"></slot>
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
        <div class="modal-body">
          ...
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Finalize</button>
        </div>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped></style>