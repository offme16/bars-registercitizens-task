<script>
import Header from "@/components/Header.vue"
import ListForm from "@/components/ListForm.vue"
import PersonList from "@/components/PersonList.vue"
import MyDialogs from "./components/UI/MyDialogs.vue"
import Loader from "./components/UI/Loader.vue";
import { mapState, mapMutations, mapActions } from "vuex"
import ButtonBox from "./components/ButtonBox.vue"
import SearchBox from "./components/SearchBox.vue"
import Print from "./components/Print.vue"
export default {
  components: {
    ListForm, PersonList, Header,
    MyDialogs, ButtonBox, SearchBox, Print, Loader
},
  data() {
    return {
      dialogVisible: false,
      dialogVisibleDuo:false,
      dialogVisibleChange: false,
      dialogPrint: false,
      changeAct: false,
      manipID: null,
    }
  },
  methods:{
    createPost(value) {
      this.$store.dispatch("createPost", value)
    },
    removeList(){
      this.dialogVisibleDuo=true;
    },
    removePost() {
      if(this.manipID == null){
        alert('Вы не выбрали запись');
      }else
      this.$store.dispatch("deletePost", this.manipID.id);
       this.swapVisible();
      },
    remove(onlyPost)  {
      this.manipID = onlyPost;
    },
    changeList(value){
      if(this.manipID === null){
        alert('Вы не выбрали запись');
      }else{this.$store.dispatch("updatePost", {id: this.manipID.id, ...value});}
      
    },
    showDialog() {
      this.dialogVisible = true;
    },
    exitDialog() {
      this.dialogVisible = false;
      this.dialogVisibleChange = false;
    },
    showDialogDuo(){
      this.dialogVisibleDuo = true;
    },
    swapVisible() {
      this.dialogVisibleDuo=false;
      this.manipID = null;
    },
    changeDialigShow() {
      this.dialogVisibleChange = true;
      this.changeAct = true;
      console.log(this.changeAct)
    },
    searchPerson({ searchValue, fullName }) {
      this.$store.dispatch("searchPersonPost", { searchValue, fullName } );
      console.log({ searchValue, fullName });
    },
    ...mapMutations({
    setList: 'setList',    
    }),
    ...mapActions({
    loadMoreList: 'loadMoreList',
    fetchList: 'fetchList'
    }),
    morePost() {
      this.$store.dispatch("loadMoreList")
    },
    printList() {
      this.dialogPrint = true;
      setTimeout(this.printFunct, 1000);
    },
    printFunct() {
      window.print();
    }
  },
  mounted(){
    this.fetchList();
  },
  computed: {
    ...mapState({
      list: state => state.list.list,
      isLoadingList: state => state.list.isLoadingList,
      page: state => state.list.page,
      limit: state => state.list.limit,
      totalpages: state => state.list.totalpages,
    }),
  },    
}
  
</script>

<template>
  <div class="wrapper">
    <Header />
    <SearchBox
    @searchPerson="searchPerson"
    />
    <ButtonBox 
    @showDialog="showDialog"
    @changeDialigShow="changeDialigShow"
    @removeList="removeList"
    @printList="printList"
    />
    <!--dialog for addPerson-->
    <my-dialogs
     v-model:show="dialogVisible">
     <h3>Анкета гражданина</h3>
      <ListForm
      @createPost="createPost"
       @exitDialog="exitDialog"  
      />
    </my-dialogs>
    <!--List-->
    <PersonList 
      :list="list"
      @removeList="remove"
      v-if="!isLoadingList"
      />
      <div class="isLoader" v-else><Loader /></div>
    <!--changeList-->
      <my-dialogs 
        v-model:show="dialogVisibleChange">
        <h3>Анкета гражданина</h3>
      <ListForm
      @changePost="changeList" 
       @exitDialog="exitDialog" 
       :changeAct="changeAct"
       :manipObj="manipID" 
      />
    </my-dialogs>
    <!--dialog Y/N-->
      <my-dialogs  v-model:show="dialogVisibleDuo">
          <h3>Вы уверены в этом?</h3>
        <div class="dialog__button">
        <button @click="removePost">ДА</button>
        <button @click="swapVisible">НЕТ</button>
        </div>
      </my-dialogs>

      <my-dialogs v-model:show="dialogPrint">
        <h3>Реестр граждан</h3>
        <Print 
          :list="list"
        />
      </my-dialogs>
      <div  class="but-f-dow"><button @click="morePost">more posts</button></div>
  </div>
  </template>
  
<style>
*{
  margin: 0 auto;
  padding: 0;
}
.wrapper{
  background: #fff;
}
button{
  border: none;
  padding: 10px 18px;
  cursor: pointer;
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  border-radius: 6px;
}
button:hover{
  background-color: rgb(161, 161, 161);
}
.add{
  margin-top: 20px;
  margin-bottom: 50px;
}
.dialog__button{
  margin-top: 5px;
  display: flex;
  justify-content: center;
}
h3{
  margin-bottom: 10px;
}
.but-f-dow{
  display: flex;
  justify-content: center;
  margin-top: 15px;
  margin-bottom: 15px;
}
.isLoader{
  display: flex;
  justify-content: center;
}
</style>
