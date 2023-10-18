<template>
    <div class="forComponent">
      <form class="search" @submit.prevent>
        <input 
              v-focus
              v-model="list.surName"
               placeholder="Введите Фамилию">
        <input 
              v-model="list.name"
               placeholder="Введите Имя">
        <input 
                v-model="list.lastName"
               placeholder="Введите Отчество">
          <input 
                 v-model="list.birthDate"
                 type="tel" v-mask="'####-##-##'"
                placeholder="Введите ГГГГ.ММ.ДД">
                <div class="search__button">
                  <button @click="choiceMetode()">Сохранить</button>
                  <button @click="exitDialog()">Выйти</button>
                </div>    
    </form>
    </div>
</template>

<script>
import {mask} from "vue-the-mask"
   export default {
    directives: {mask},
    data() {
      return {
        list: {
          name: "",
          surName: "",
          lastName: "",
          birthDate: "",
        }, 
      }
    },
    props:{
      changeAct: {
            type: Boolean
      },
      manipObj: {
            type: Object
      }
    },
    created() {
    if (this.changeAct && this.manipObj) {
      this.list = { ...this.manipObj };
    }
  },
    methods: {
      createNewPost() {
        this.$emit('createPost', this.list)
          this.clearField();
        },
      changeList(){
          this.$emit('changePost', this.list)
          this.clearField();
        },
      async choiceMetode() {
        this.changeAct ? this.changeList() : this.createNewPost();

      },
      exitDialog() {
        this.$emit('exitDialog', false)
      },
      clearField() {
        this.list = {
          surName: '',
          name: '',
          lastName: '',
          birthDate: ''
        }
      }
    },
}
</script>

<style scoped>
.search{
  display: flex;
  flex-direction: column;
  gap: 10px;
  }
input{
  border: none;
  padding: 10px 10px;
  background-color: rgba(222, 228, 230, 0.621);
  border-radius: 8px;
}
.search__button{
  display: flex;
  gap: 10px;
}
</style>