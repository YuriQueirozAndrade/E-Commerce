import Header from "@components/header/Header.jsx";
import Footer from "@components/footer/Footer.jsx";
import Modal from "@components/modal/Modal.jsx";
import "./home.css";
export default function Home()
{
  return (
  <>
    <Header />
    <main className="mainContent">
      <h1>Hellow World!!!!</h1>
      <Modal />
      <h1>Hellow World!!!!</h1>
      <Modal />
    </main>
    <Footer />
  </>
  )
}
