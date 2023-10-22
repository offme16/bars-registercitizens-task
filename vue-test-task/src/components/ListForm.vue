<template>
  <div class="forComponent">
    <form class="search" @submit.prevent>
      <input 
        v-focus
        v-model="list.surName"
        @input="validateText('surName')"
        :class="{ 'is-invalid': formSub && !list.surName }"
        placeholder="Введите Фамилию"
      >
      <input 
        v-model="list.name"
        @input="validateText('name')"
        :class="{ 'is-invalid': formSub && !list.name }"
        placeholder="Введите Имя"
      >
      <input 
        v-model="list.lastName"
        @input="validateText('lastName')"
        :class="{ 'is-invalid': formSub && !list.lastName }"
        placeholder="Введите Отчество"
      >
      <input 
        v-model="list.birthDate"
        type="tel" v-mask="'####-##-##'"
        placeholder="Введите ГГГГ.ММ.ДД"
        :class="{ 'is-invalid': formSub && !list.birthDate }"
      >
      <div class="search__button">
        <button @click="choiceMetode">Сохранить</button>
        <button @click="exitDialog">Выйти</button>
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
      formSub: false
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
      if (this.checkInput()) {
        this.$emit("createPost", this.list);
        this.clearField();
        this.formSub = false;
      }
    },
    changeList() {
      if (this.checkInput()) {
        this.$emit("changePost", this.list);
        this.clearField();
        this.formSub = false;
      }
    },
    async choiceMetode() {
      this.formSub = true;
      if (this.changeAct) {
        this.changeList();
      } else {
        this.createNewPost();
      }
    },
    exitDialog() {
      this.$emit('exitDialog', false);
    },
    clearField() {
      this.list = {
        surName: '',
        name: '',
        lastName: '',
        birthDate: ''
      };
    },
    checkInput() {
      return (
        this.list.name !== "" &&
        this.list.surName !== "" &&
        this.list.lastName !== "" &&
        this.list.birthDate !== ""
      );
    },
    validateText(prop) {
      this.list[prop] = this.list[prop].replace(/[^A-Za-zА-Яа-яЁё]/g, '');
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
.is-invalid {
  border: 1px solid red;
}
</style>
