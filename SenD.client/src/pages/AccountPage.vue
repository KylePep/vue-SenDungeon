<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12 mb-3">
        <section class="row d-flex justify-content-center">
          <div class="col-9 cover-img position-relative m-3 rounded">
            <img class="profile-avatar" :src="activeProfile.picture" :alt="activeProfile.name">
          </div>
          <div class="ms-3 fs-4 col-9 d-flex justify-content-end" type="button" data-bs-toggle="modal"
            data-bs-target="#accountFormModal">
            <i class="mdi mdi-dots-horizontal p-0  selectable"></i>
          </div>
        </section>
        <div class="text-center fs-3">
          {{ activeProfile.name }}
        </div>
      </div>

    </section>
  </div>

  <AccountForm />
</template>

<script>
import { computed, onUnmounted, watchEffect } from 'vue';
import { AppState } from '../AppState';
import { accountService } from "../services/AccountService.js";
import Pop from "../utils/Pop.js";
import AccountForm from "../components/AccountForm.vue";
export default {
  setup() {
    async function getProfileById(profileId) {
      try {
        await accountService.getProfileById(profileId);
      }
      catch (error) {
        Pop.error(error.message, '[ERROR OCCURED- getProfileById]');
      }
    }

    watchEffect(() => {
      getProfileById(AppState.account.id);
    });
    onUnmounted(() => {
      AppState.activeProfile = {}
    })
    return {
      AppState: computed(() => AppState),
      activeProfile: computed(() => AppState.activeProfile),
      coverImg: computed(() => `url("${AppState.account.coverImg}")`),
    };
  },
  components: { AccountForm }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.cover-img {
  height: 25vh;
  background-position: center;
  background-size: cover;
  background-image: v-bind(coverImg);
}
</style>
