<template>
<!-- <div style="width: 100%; height: 100%;display:flex; justify-content: center; align-items: center"> -->
  <div class="modal-confirm" :class="{'show-popup': this.isShow}">
    <div class="modal-content">
      <div class="content-confirm">
        <div class="title-popup flex">
          <div class="img-confirm"></div>
          <div class="text-confirm">
            Các trường bắt buộc cần nhập đủ thông tin
          </div>
        </div>
        <div class="btn-popup flex"> 
              <Button typeBtn="close" textBtn="Đóng" @btnOnclick="btnPopUpOnclick" />
        </div>
      </div>
    </div>
  </div>
  <!-- </div> -->
</template>

<script>
import Button from '../base/BaseButton.vue'
export default {
  name: "PopUpWarning",
  components: {Button},
  data() {
    return {
      isShow: false,
    }
  },
  methods: {
    /**
     * sự kiện open popup
     * Author: DTsang(31/08)
     */
    openPopupWarrning()
    {
      this.isShow = true;
    },
    /**
     * Bắt sự kiện click vào nút trong pop up
     * Author: DTSang(31/08)
     */
    btnPopUpOnclick(){
        this.closePopupWarning();
    },
    /**
     * Sự kiện đóng popup
     * Author: DTSang(31/08)
     */
    closePopupWarning()
    {
      this.isShow = false;
      this.$emit("closePopupWarning")
    },
  },
};
</script>

<style scoped>
.modal-confirm {
  display: none;
  position: fixed;
   left:35%;
  top: 35%;
  width:546px;
  height: 250px;
  overflow: auto;
  background-color: rgb(0, 0, 0);
  background-color: rgba(0, 0, 0, 0.4);
  z-index: 9;
}
.show-popup{
    display: block;
}
.modal-content {
  background-color: #fefefe;
  margin: auto;
  border: 1px solid #888;
  border-radius: 8px;
  width: 100%;
  height: 100%;
  position: relative;
}
.content-confirm {
  height: 100%;
  margin: 32px;
}
.title-popup
{
  height: 60%;
  border-bottom: 1px solid gray;
  display:flex;
  justify-content: center;
  align-items: center;
  font-family: Misa-Regular;
  font-size: 18px;
}
.btn-popup {
    height: 40%;
    display:flex;
    justify-content: center;
    align-items: center;
    padding: 8%;
}
.img-confirm
{
    background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -598px -463px;
    width: 48px;
    height: 48px;
    margin-top: 6px;
    margin-left: 2px;
}
</style>