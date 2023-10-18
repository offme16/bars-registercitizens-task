<template>
     <div class="buttons">
      <button class="add" @click="showDialog">Добавить</button>
      <button class="add" @click="changeDialigShow">Изменить</button>
      <button class="add" @click="removeList">Удалить</button>
      <button class="add" @click="printList">Печать</button>
    </div>
</template>

<script>
    export default{
        methods: {
            showDialog() {
                this.$emit("showDialog")
            },
            changeDialigShow() {
                this.$emit("changeDialigShow")
            },
            removeList() {
                this.$emit("removeList")
            },
            printList() {
                this.$emit("printList")
            }
        }
    }
</script>

<style>
.buttons{
    width: 50%;
    display: flex;
    justify-content: center;
}
</style>