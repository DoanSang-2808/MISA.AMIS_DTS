<template>
    <div class="header">
      <div class="header-left">
        <div class="icon24 icon-option"></div>
        <div class="option">
          <div class="option-text">
            CÔNG TY SẢN XUẤT - THƯƠNG MẠI - DỊCH VỤ QUI PHÚC
          </div>
          <div class="icon24 option-icon"></div>
        </div>
      </div>
      <div class="header-right">
        <div class="icon24 notify"></div>
        <div class="account-info">
          <div class="account-info-wrapper">
            <div class="avatar-icon"></div>
            <div class="account-text">Đoàn Thị Sáng</div>
            <div class="icon24 mi"></div>
          </div>
        </div>
      </div>
    </div>
</template>

<script>
export default {
  name: "Header",
  conponents: {},
};
</script>

<style scoped>
.header {
  position: absolute;
  top: 0px;
  left: 178px;
  height: 48px;
  width: calc(100vw - 178px);
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.header-left {
  display: flex;
  align-items: center;
  height: 100%;
  font-family: Misa-Bold;
}
.option {
  display: flex;
}
.option-text {
  padding: 10px;
  min-width: 160px;
  text-overflow: ellipsis;
}
.icon24 {
  width: 24px;
  height: 24px;
}
.icon-option {
  margin: 0 10px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -843px -31px;
}
.option-icon {
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -1129px -348px;
}
.header-right {
  display: flex;
  justify-content: center;
  align-items: center;
}
.notify {
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -788px -30px;
}
.account-info {
  padding-right: 20px;
}
.account-info-wrapper {
  padding: 0 0px 0 16px;
  display: flex;
  align-items: center;
  font-family: Misa-Regular;
}
.avatar-icon {
  margin-right: 10px;
  width: 32px;
  height: 32px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -352px -894px;
  border-radius: 50%;
}
.mi {
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -1119px -355px;
}
</style>
