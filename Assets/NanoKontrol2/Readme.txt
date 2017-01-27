2015/02/10 @from2001vr
http://goo.gl/P5zRpx
http://www.ozmiq.com/labs/vr/

KORG社のnanoKONTROL2の情報をUnityから利用するためのスクリプト・プレハブ・デモシーン及びMIDI情報取得用のプラグイン（unity-midi-receiver）ファイル一式です。

利用方法
NanoKontrol2_projectを開くかNanoKontrol2.unitypackageを既存のプロジェクトにインポートしてください。

/NanoKontrol2/Prefab/NanoKontrol2プレハブをヒエラルキービューに追加します。
NanoKontrol2のボタンが押されたりスライダ・ノブの値が変化するとNanoKontrol2プレハブのインスペクタ情報値が変化します。

スクリプトから情報を取得するには
SampleScript_for_NanoKontrol2スクリプトを任意のGameObjctにアタッチしてください。
NanoKontrol2のボタンが押されたりスライダ・ノブの値が変化するとConsoleにログが表示されます。SampleScript_for_NanoKontrol2スクリプトを参考にコードを改造してください。

デモ
/NanoKontrol2/Demo/Demo1シーン
スライダー1の値に合わせてオブジェクトのサイズが変わるシンプルなデモ

/NanoKontrol2/Demo/Demo2シーン
各スライダー・ノブに合わせてオブジェクトのサイズ・角度が変わるサンプル
SMRボタンをおすことによりオブジェクトの色が変化します

ライセンス
本プロジェクトはkeijiro氏の作成した
unity-midi-receiver
https://github.com/keijiro/unity-midi-receiver
及び
unity-midi-receiver-test
https://github.com/keijiro/unity-midi-receiver-test
の一部ソースコードを変更し、新たなスクリプト・プレハブ・デモシーンを追加したものです。
unity-midi-receiver及びunity-midi-receiver-testは下記のライセンスにより公開されております。
新たにNanoKontrol2用に追加されたコードも同様に自由に利用していただいた構いません。

License

Copyright (c) 2013 Keijiro Takahashi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
























