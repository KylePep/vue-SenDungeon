<script setup>
const props = defineProps(["monsterData"])
</script>


<template>
  <div class="bg-dark text-light rounded p-3 d-flex flex-column justify-content-center align-items-center">
    <div>
      Name:
      {{ props.monsterData.name }}
    </div>
    <img :src="props.monsterData.img" alt="">
    <div>
      Type:
      {{ props.monsterData.type }}
      Sub-Type:
      {{ props.monsterData.subType }}
    </div>
    <div>
      Description:
      {{ props.monsterData.description }}
    </div>
    <div>
      Power:
      {{ props.monsterData.power }}
      Toughness:
      {{ props.monsterData.toughness }}
    </div>
  </div>
</template>


<style lang="scss" scoped></style>