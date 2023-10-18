<template>
  <div>
    <div class="title">
        <div class="title-list" >Фамилия</div>
            <div class="title-list">Имя</div>
            <div class="title-list">Отчество</div>
            <div class="title-list">Дата рождения</div>
      </div>    
    <div class="ssss"  v-if="list.length>0">  
      <TransitionGroup name="list">
        <ListItem
            :item="item"
            :key="item.id"
            v-for="item in list"
            @getId="remove"
            /> 
      </TransitionGroup>
    </div>
      <h2 v-else>Список пуст!</h2>
  </div>
       
</template>

<script>
import ListItem  from '@/components/ListItem.vue'

  export default {
    props: {
        list: {
            type: Object,
            required: true,
        }
    },
    components: {
      ListItem
    },
    methods: {
      remove (ID) {
        const remID = ID;
        this.$emit('removeList',remID)
      }
    }
}
</script>

<style scoped>

 .ssss{
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 10px;
 }
h2{
  text-align: center;
}
.list-enter-active,
.list-leave-active {
  transition: all 0.5s ease;
}
.list-enter-from,
.list-leave-to {
  opacity: 0;
  transform: translateX(30px);
}
.title{
  width: 1020px;
  display: flex;
  background: #cac6c6;
  margin-bottom: 5px;
}
.title :nth-child(1){
  border-right: none;
}
.title :nth-child(2){
  border-right: none;
}
.title :nth-child(3){
  border-right: none;
}
.title-list{
  border: 2px solid ;
  width: 100%;
  padding: 10px 10px;
  text-align: center;
  font-family:  Georgia, serif;
}
</style>