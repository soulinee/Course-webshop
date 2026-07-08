 
import Header from '../components/Header'
import { Outlet } from 'react-router-dom'
import Footer from '../components/Footer'

const RootLayout = () => {
  return (
    <div className="rootLayout">
      <Header />
      <div className="outletStyle">
        <Outlet />
      </div>
      <Footer />
    </div>
  )
}

export default RootLayout
