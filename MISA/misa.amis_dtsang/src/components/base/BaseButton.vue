<template>
    <button class="btn" :id="typeBtn" @click="btnOnclick(typeBtn)">
        {{textBtn}}
    </button>
</template>

<script>
export default {
    name: "Button",
    components: {},
    props: {
        typeBtn: {
            type: String,
        },
        textBtn: {
            type: String,
        },
    },
    methods:{
        /**
         * Hàm bắt sự kiện khi click vào nút
         * Author: DTSang(31/08)
         */
        btnOnclick(typeBtn){
           this.$emit("btnOnclick", typeBtn)
        }
    }
}
</script>

<style scoped>
.btn{
    height:40px;
    border-radius: 4px;
    padding: 0 24px 0 24px;
    background-color: #2ca01c;
    color: #fff;
    font-family: Misa-Regular;
}
.btn:hover{
   background-color: #35bf22; 
}
#cancel, #save, #no-comfirm {
  background-color: #fff !important; 
  color: #000;
  border: 1px solid #ccc;
  font-weight:bold;
  margin-right: 10px;
}
</style>