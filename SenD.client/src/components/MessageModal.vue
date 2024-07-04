<script setup></script>


<template>

  <!-- Modal -->
  <div class="modal fade" id="MessageModal" tabindex="-1" aria-labelledby="MessageModalLabel"
    aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="MessageModalLabel"> Write a Message </h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <form @submit.prevent="" action="">
          <div class="modal-body">
            <div class="mb-3">
              <label for="recipientInput" class="form-label">Recipient</label>
              <input type="string" class="form-control" id="recipientInput" placeholder="recipient">
            </div>
            <div class="mb-3">
              <label for="ContentInput" class="form-label">Message</label>
              <textarea class="form-control" id="ContentInput" rows="3"></textarea>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Send</button>
          </div>
        </form>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>

</style>