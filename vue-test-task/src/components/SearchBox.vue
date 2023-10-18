<template>
<div class="main">
      <form class="search" @submit.prevent>
        <div>
          <h3>Фамилия</h3>
          <input v-model="searchValue.surName" placeholder="Введите сюда...">
        </div>
        <div>
          <h3>Имя</h3>
          <input v-model="searchValue.name" placeholder="Введите Имя">
        </div>
        <div>
          <h3>Отчество</h3>
          <input v-model="searchValue.lastName" placeholder="Введите Отчество">
        </div>
        <div>
          <h3>Дата рождения с:</h3>
          <input v-model="searchValue.dateStringStart" type="tel" v-mask="'####-##-##'" placeholder="ГГГГ.ММ.ДД">
        </div>
        <div>
          <h3>по:</h3>
          <input v-model="searchValue.dateStringEnd" type="tel" v-mask="'####-##-##'" placeholder="ГГГГ.ММ.ДД">
        </div>
       
        <button @click="searchPerson">ПОИСК</button>
      </form>
    </div>
</template>

<script>
import {mask} from "vue-the-mask"
    export default {
        directives: {mask},
        data() {
      return {
        searchValue: {
          surName: "",
          name: "",
          lastName: "",
          dateStringStart: "",
          dateStringEnd: "",
        }, 
      }
    },
        methods: {
            searchPerson(){
                this.$emit('searchPerson', { fullName: this.fullName, searchValue: this.searchValue})
            }
        },
        computed: {
    fullName() {
      return `${this.searchValue.name} ${this.searchValue.surName} ${this.searchValue.lastName}`
    },
  },
  }
</script>

<style scoped>
.main{
  padding-top: 25px;
  width: 70%;
}
.search{
  display: flex;
  align-items: flex-end;
}
input{
  border: 1px solid grey;
  padding: 10px 15px;
  border-radius: 8px;
}

</style>