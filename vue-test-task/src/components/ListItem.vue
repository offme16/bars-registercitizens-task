<template>
        <div class="container" @click="getId" :class="{ 'clicked-container': clicked }">
            <div class="container-list">{{item.surName}}</div>
            <div class="container-list">{{item.name}}</div>
            <div class="container-list">{{item.lastName}}</div>
            <div class="container-list">{{item.birthDate}}</div>
      </div>
</template>

<script>
export default{
  data() {
  return {
    clicked: false
  };
},
    props: {
        item: {
            type: Object,
            required:true,
        }
    },
    methods:{
        getId(){
            const ID = this.item;
            this.$emit('getId', ID);
            this.clicked = !this.clicked;
          },
        }
}
</script>
<style scoped>
.container-list{
  border: 2px solid ;
  width: 100%;
  padding: 10px 10px;
  text-align: center;
  cursor: pointer;
  font-family:  Georgia, serif;
}
.container :nth-child(1){
  border-right: none;
}
.container :nth-child(2){
  border-right: none;
}
.container :nth-child(3){
  border-right: none;
}
.container{
    width: 1020px;
    display: flex;
    background: #fff;

 }
 .container:hover{
  color: #fff;
    background: rgb(143, 143, 143);
 }
 .clicked-container {
  color: #fff;
  background: rgb(143, 143, 143);
}
</style>