<template>
<div class="margin-back">
    <div class="container" :key="item.id"
                           v-for="item in list">
            <div class="container-list">{{item.surName}}</div>
            <div class="container-list">{{item.name}}</div>
            <div class="container-list">{{item.lastName}}</div>
            <div class="container-list">{{item.birthDate}}</div>
      </div>
</div>
</template>

<script>
export default{
    props: {
        list: {
            type: Object,
            required:true,
        }
    },
}
</script>


<style scoped>
.container-list{
  border: 3px solid ;
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
.margin-back{
    height: 920px;
}
</style>